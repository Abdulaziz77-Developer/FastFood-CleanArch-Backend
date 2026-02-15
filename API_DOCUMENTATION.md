# 🚀 API Документация - FastFoodApp Backend

## Базовый URL
```
https://localhost:5001/api
```

## Аутентификация

### 1. Регистрация пользователя
**POST** `/api/auth/register`

**Request:**
```json
{
  "email": "user@example.com",
  "fullName": "John Doe",
  "password": "SecurePassword123"
}
```

**Response (200 OK):**
```json
{
  "message": "User registered successfully",
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIs...",
    "refreshToken": "base64-encoded-refresh-token",
    "tokenType": "Bearer",
    "expiresIn": 3600,
    "user": {
      "id": "550e8400-e29b-41d4-a716-446655440000",
      "fullName": "John Doe",
      "email": "user@example.com",
      "role": "Customer"
    }
  }
}
```

---

### 2. Логин пользователя
**POST** `/api/auth/login`

**Request:**
```json
{
  "email": "user@example.com",
  "password": "SecurePassword123"
}
```

**Response (200 OK):**
```json
{
  "message": "Login successful",
  "data": {
    "accessToken": "eyJhbGciOiJIUzI1NiIs...",
    "refreshToken": "base64-encoded-refresh-token",
    "tokenType": "Bearer",
    "expiresIn": 3600,
    "user": {
      "id": "550e8400-e29b-41d4-a716-446655440000",
      "fullName": "John Doe",
      "email": "user@example.com",
      "role": "Customer"
    }
  }
}
```

---

### 3. Google OAuth Login
**POST** `/api/auth/google`

**Request:**
```json
{
  "idToken": "google-id-token-from-client"
}
```

**Response (200 OK):**
```json
{
  "message": "Google login successful",
  "data": {
    "accessToken": "...",
    "refreshToken": "...",
    "tokenType": "Bearer",
    "expiresIn": 3600,
    "user": { ... }
  }
}
```

---

### 4. Facebook OAuth Login
**POST** `/api/auth/facebook`

**Request:**
```json
{
  "accessToken": "facebook-access-token-from-client"
}
```

**Response (200 OK):**
```json
{
  "message": "Facebook login successful",
  "data": { ... }
}
```

---

### 5. Refresh Token
**POST** `/api/auth/refresh`

**Request:**
```json
{
  "refreshToken": "base64-encoded-refresh-token"
}
```

**Response (200 OK):**
```json
{
  "message": "Token refreshed successfully",
  "data": { ... }
}
```

---

### 6. Get Current User
**GET** `/api/auth/me`

**Headers:**
```
Authorization: Bearer <access-token>
```

**Response (200 OK):**
```json
{
  "message": "User data retrieved successfully",
  "data": {
    "id": "550e8400-e29b-41d4-a716-446655440000",
    "fullName": "John Doe",
    "email": "user@example.com",
    "role": "Customer"
  }
}
```

---

## Foods (Продукты)

### 1. Get All Foods
**GET** `/api/foods`

**Response:**
```json
{
  "message": "Foods retrieved successfully",
  "data": [
    {
      "id": "...",
      "name": "Burger",
      "description": "Delicious burger",
      "price": 9.99,
      "imageUrl": "...",
      "isAvailable": true,
      "categoryId": "...",
      "categoryName": "Fast Food",
      "supplierId": "...",
      "supplierName": "Burger King"
    }
  ]
}
```

---

### 2. Get Food By ID
**GET** `/api/foods/{id}`

**Response:**
```json
{
  "message": "Food retrieved successfully",
  "data": { ... }
}
```

---

### 3. Get Foods By Category
**GET** `/api/foods/category/{categoryId}`

**Response:**
```json
{
  "message": "Foods retrieved successfully",
  "data": [ ... ]
}
```

---

### 4. Create Food
**POST** `/api/foods`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin, Supplier
```

**Request:**
```json
{
  "name": "Burger",
  "description": "Delicious burger",
  "price": 9.99,
  "imageUrl": "https://...",
  "categoryId": "...",
  "supplierId": "..."
}
```

---

### 5. Update Food
**PUT** `/api/foods/{id}`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin, Supplier
```

**Request:**
```json
{
  "name": "Updated Burger",
  "description": "More delicious",
  "price": 10.99,
  "imageUrl": "https://...",
  "isAvailable": true,
  "categoryId": "..."
}
```

---

### 6. Delete Food
**DELETE** `/api/foods/{id}`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin, Supplier
```

---

## Categories (Категории)

### 1. Get All Categories
**GET** `/api/categories`

**Response:**
```json
{
  "message": "Categories retrieved successfully",
  "data": [
    {
      "id": "...",
      "name": "Fast Food"
    }
  ]
}
```

---

### 2. Get Category By ID
**GET** `/api/categories/{id}`

---

### 3. Create Category
**POST** `/api/categories`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin
```

**Request:**
```json
{
  "name": "Fast Food"
}
```

---

### 4. Update Category
**PUT** `/api/categories/{id}`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin
```

---

### 5. Delete Category
**DELETE** `/api/categories/{id}`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin
```

---

## Orders (Заказы)

### 1. Get All Orders (Admin Only)
**GET** `/api/orders`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin
```

---

### 2. Get Order By ID
**GET** `/api/orders/{id}`

**Headers:**
```
Authorization: Bearer <access-token>
```

---

### 3. Get My Orders
**GET** `/api/orders/my-orders`

**Headers:**
```
Authorization: Bearer <access-token>
```

**Response:**
```json
{
  "message": "User orders retrieved successfully",
  "data": [
    {
      "id": "...",
      "createdAt": "2026-02-14T10:00:00Z",
      "totalAmount": 25.50,
      "status": "Pending",
      "deliveryAddress": "123 Main St"
    }
  ]
}
```

---

### 4. Get Orders By Status
**GET** `/api/orders/status/{status}`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin, Courier
```

---

### 5. Create Order
**POST** `/api/orders`

**Headers:**
```
Authorization: Bearer <access-token>
```

**Request:**
```json
{
  "userId": "550e8400-e29b-41d4-a716-446655440000",
  "deliveryAddress": "123 Main St",
  "status": "Pending"
}
```

---

### 6. Update Order Status
**PATCH** `/api/orders/{id}/status`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin, Courier
```

**Request:**
```json
{
  "status": "Processing"
}
```

---

## Suppliers (Поставщики)

### 1. Get All Suppliers
**GET** `/api/suppliers`

---

### 2. Get Supplier By ID
**GET** `/api/suppliers/{id}`

---

### 3. Get Supplier By User ID
**GET** `/api/suppliers/user/{userId}`

---

### 4. Get Suppliers By City
**GET** `/api/suppliers/city/{city}`

---

### 5. Create Supplier
**POST** `/api/suppliers`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin
```

---

### 6. Update Supplier
**PUT** `/api/suppliers/{id}`

**Headers:**
```
Authorization: Bearer <access-token>
Roles Required: Admin, Supplier
```

---

## Error Responses

### 400 Bad Request
```json
{
  "message": "Invalid request data"
}
```

### 401 Unauthorized
```json
{
  "message": "Invalid email or password"
}
```

### 403 Forbidden
```json
{
  "message": "You do not have permission to access this resource"
}
```

### 404 Not Found
```json
{
  "message": "Resource not found"
}
```

### 500 Internal Server Error
```json
{
  "message": "An error occurred while processing your request"
}
```

---

## Authorization Roles

- **Customer**: Default role for all new users
- **Admin**: Full access to all resources
- **Supplier**: Can create and manage foods
- **Courier**: Can view and update order statuses

---

## Testing in Postman/Thunder Client

### Setup Headers for Protected Endpoints:
```
Authorization: Bearer <your-access-token>
Content-Type: application/json
```

### Example Authorization Header:
```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

---

## Running the Application

```bash
cd FastFoodAppBackend
dotnet run --project FastFoodApp.WebApi
```

The API will be available at: `https://localhost:5001`
