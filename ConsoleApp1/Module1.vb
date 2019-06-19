Imports System
Imports System.Collections.Generic
Imports System.Security.Claims
Imports Microsoft.IdentityModel.Tokens
Imports System.IdentityModel.Tokens.Jwt
Module Module1

    Sub Main()

        Dim _idMerchant As String = ""

        Dim _keyJwt As String = ""

        Dim claims = New List(Of Claim)()
        ' Obrigatorio
        claims.Add(New Claim("jti", Guid.NewGuid().ToString()))
        ' (Scope) Claim
        claims.Add(New Claim("scope", "Payments.Authorize"))

        Dim stringNull As String = Nothing
        Dim dateNull As Nullable(Of Date)

        Dim payload = New JwtPayload(
            _idMerchant, ' iss
            stringNull,
            claims,
            dateNull,
            dateNull,
            DateTime.UtcNow ' iat
            )

        Dim header = New JwtHeader(
            New SigningCredentials(
                New SymmetricSecurityKey(Convert.FromBase64String(_keyJwt)),
                "HS256"
                )
            )

        Dim jwt = New JwtSecurityToken(header, payload)

        Dim encodedJwt = New JwtSecurityTokenHandler().WriteToken(jwt)

        Console.WriteLine(encodedJwt)

        Console.Read()


    End Sub

End Module
