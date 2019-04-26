using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Base.Factory
{
    static public class JWTFactory
    {
        #region Create JwtSecurityToken.
        /// <summary>
        /// Create Roles JWT
        /// </summary>
        /// <param name="userUuid"></param>
        /// <param name="userRoles"></param>
        /// <param name="signKey"></param>
        /// <param name="expires"></param>
        /// <param name="securityAlgorithms"></param>
        /// <returns>JwtSecurityToken</returns>
        static public JwtSecurityToken CreateJWT(string userUuid, List<string> userRoles, string signKey, DateTime expires, string securityAlgorithms = SecurityAlgorithms.HmacSha256)
        {
            List<Claim> claims = new List<Claim> {
                //自訂payload附帶其他Identity其他屬性的type & value map宣告
                new Claim(JwtRegisteredClaimNames.NameId, userUuid)
            };

            if (userRoles != null)
            {
               claims.AddRange(userRoles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
            SigningCredentials creds = new SigningCredentials(key, securityAlgorithms);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return token;
        }
        #endregion

        #region Create JwtTokenString.
        static public string JwtTokenString(JwtSecurityToken jwtSecurityToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            if (tokenHandler.CanWriteToken)
            {
                return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            else
            {
                return null;
            }
            
        }
        #endregion

        #region DeCode JwtTokenString.
        static public JwtSecurityToken ReadJwtTokenString(string jwtString)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadJwtToken(jwtString);

            return tokenS;
        }
        #endregion

        #region DeCode JwtTokenString.
        static public string GetJwtTokenNameId(JwtSecurityToken jwtSecurityToken)
        {
            var nameId = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId).Value;

            return nameId;
        }
        #endregion

    }
}