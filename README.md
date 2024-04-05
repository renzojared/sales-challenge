
# Sales project

Web Api to manage sales

## Technologies

 - **.NET 7**
 - **Entity Framework Core**
 - **SQL Server**
 - Swagger

## Environment Variables

To run this project, you will need to change the following environment variables in appsettings.json

`ConnectionString`

Must contain own local connection string

To add and update migration you also need to change in `SalesContextFactory.cs`

## API Endpoints

#### Token JWT

```http
  POST api/LogIn/Token
```

```json
{
  "username": "user1@company.com",
  "password": "MM@11"
}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `username` | `string` | **Required**. The email of employee |
| `password` | `string` | **Required**. The secrect password |

![App Screenshot](https://github.com/renzojared/sales-challenge/blob/main/docs/img/tokenresponse.png)

Then add Bearer to Swagger to use other endpoints

![App Screenshot](https://github.com/renzojared/sales-challenge/blob/main/docs/img/tokenauthorize.png)

#### Create Order

```http
  POST api/Order/Create
```

```json
{
  "products": [
    1,2
  ],
  "sellerCode": "MM11",
  "delivererCode": "MM12"
}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `products` | `int[]` | **Required**. Array of products id |
| `sellerCode` | `string` | **Required**. The user code of seller |
| `delivererCode` | `string` | **Required**. The user code of deliverer |

#### Change State Order

```http
  POST api/Order/NextState
```

```json
{
  "orderNumber": "10001"
}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `orderNumber` | `string` | **Required**. The orderNumber returns at order/create |
