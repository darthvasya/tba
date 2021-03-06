﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Infrastructure;
using tba.Common.Helpers;
using tba.Model;

namespace tba.API.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create ( AuthenticationTokenCreateContext context )
        {
            throw new NotImplementedException ( );
        }

        public async Task CreateAsync ( AuthenticationTokenCreateContext context )
        {
            var clientid = context.Ticket.Properties.Dictionary [ "as:client_id" ];

            if ( string.IsNullOrEmpty ( clientid ) )
                return;

            var refreshTokenId = Guid.NewGuid ( ).ToString ( "n" );

            using ( var _repo = new AuthRepository ( ) )
            {
                var refreshTokenLifeTime = context.OwinContext.Get < string > ( "as:clientRefreshTokenLifeTime" );

                var token = new RefreshToken
                {
                    Id = Crypto.GetHash ( refreshTokenId ),
                    ClientId = clientid,
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes ( Convert.ToDouble ( refreshTokenLifeTime ) )
                };

                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

                token.ProtectedTicket = context.SerializeTicket ( );

                var result = _repo.AddRefreshToken ( token );

                if ( result )
                    context.SetToken ( refreshTokenId );
            }
        }

        public void Receive ( AuthenticationTokenReceiveContext context )
        {
            var allowedOrigin = context.OwinContext.Get < string > ( "as:clientAllowedOrigin" );
            context.OwinContext.Response.Headers.Add ( "Access-Control-Allow-Origin", new[] {allowedOrigin} );

            var hashedTokenId = Crypto.GetHash ( context.Token );

            using ( var _repo = new AuthRepository ( ) )
            {
                var refreshToken = _repo.FindRefreshToken ( hashedTokenId );

                if ( refreshToken != null )
                {
                    //Get protectedTicket from refreshToken class
                    context.DeserializeTicket ( refreshToken.ProtectedTicket );
                    var result = _repo.RemoveRefreshToken ( hashedTokenId );
                }
            }
        }

        public async Task ReceiveAsync ( AuthenticationTokenReceiveContext context )
        {
            var allowedOrigin = context.OwinContext.Get < string > ( "as:clientAllowedOrigin" );
            context.OwinContext.Response.Headers.Add ( "Access-Control-Allow-Origin", new[] {allowedOrigin} );

            var hashedTokenId = Crypto.GetHash ( context.Token );

            using ( var _repo = new AuthRepository ( ) )
            {
                var refreshToken = _repo.FindRefreshToken ( hashedTokenId );

                if ( refreshToken != null )
                {
                    //Get protectedTicket from refreshToken class
                    context.DeserializeTicket ( refreshToken.ProtectedTicket );
                    var result = _repo.RemoveRefreshToken ( hashedTokenId );
                }
            }
        }
    }
}