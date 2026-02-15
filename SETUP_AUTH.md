# 📦 Необходимые NuGet Пакеты

Установите следующие пакеты для работы аутентификации и JWT:

## Для FastFoodApp.Infrastructure

```
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package BCrypt.Net-Next
dotnet add package Google.Apis.Auth
```

## Для FastFoodApp.WebApi

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.Authentication.Google
dotnet add package Microsoft.AspNetCore.Authentication.Facebook
```

## Установка через Package Manager Console

### FastFoodApp.Infrastructure:
```
Install-Package System.IdentityModel.Tokens.Jwt
Install-Package Microsoft.IdentityModel.Tokens
Install-Package BCrypt.Net-Next
Install-Package Google.Apis.Auth
```

### FastFoodApp.WebApi:
```
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
Install-Package Microsoft.AspNetCore.Authentication.Google
Install-Package Microsoft.AspNetCore.Authentication.Facebook
```

## Конфигурация appsettings.json

Обновите `appsettings.json` со следующими настройками:

```json
{
  "JwtSettings": {
    "SecretKey": "your-super-secret-key-that-is-at-least-32-characters-long-change-this",
    "Issuer": "FastFoodApp",
    "Audience": "FastFoodAppUsers",
    "ExpirationMinutes": 60,
    "RefreshTokenExpirationDays": 7
  },
  "Google": {
    "ClientId": "your-google-client-id-here",
    "ClientSecret": "your-google-client-secret-here"
  },
  "Facebook": {
    "AppId": "your-facebook-app-id-here",
    "AppSecret": "your-facebook-app-secret-here"
  }
}
```

## Получение OAuth Credentials

### Google OAuth
1. Перейдите на https://console.cloud.google.com
2. Создайте новый проект
3. Активируйте Google+ API
4. Перейдите в "Credentials" и создайте OAuth 2.0 Client ID
5. Скопируйте Client ID и Client Secret

### Facebook OAuth
1. Перейдите на https://developers.facebook.com
2. Создайте новое приложение
3. Добавьте платформу "Website"
4. Скопируйте App ID и App Secret

## Примеры API Endpoints

### Регистрация
```bash
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "fullName": "John Doe",
  "password": "SecurePassword123"
}
```

### Логин
```bash
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "SecurePassword123"
}
```

### Ответ
```json
{
  "accessToken": "eyJhbGciOiJIUzI1NiIs...",
  "refreshToken": "base64-encoded-refresh-token",
  "tokenType": "Bearer",
  "expiresIn": 3600,
  "user": {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "fullName": "John Doe",
    "email": "user@example.com",
    "role": "Customer"
  }
}
```

### Использование Access Token
```bash
GET /api/foods
Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```
