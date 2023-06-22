# SQL Query

-- Veritabanını oluştur
CREATE DATABASE TestDb;
GO

-- TestDb veritabanını kullan
USE TestDb;
GO

-- Transactions tablosunu oluştur
CREATE TABLE Transactions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TransactionId VARCHAR(50),
    CustomerId VARCHAR(50),
    OrderId VARCHAR(50),
    [Type] VARCHAR(50),
    Amount VARCHAR(50),
    Pan VARCHAR(50),
    CVV VARCHAR(10),
    ExpMonth VARCHAR(2),
    ExpDay VARCHAR(2)
);

-- Customers tablosunu oluştur
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId VARCHAR(50),
    Name VARCHAR(50),
    Surname VARCHAR(50),
    BirthDate VARCHAR(10),
    IdentityNo VARCHAR(20),
    IdentityNoVerified VARCHAR(5),
    Status VARCHAR(50)
);


# Postman

{
	"info": {
		"_postman_id": "09eaa4ad-ecc4-45c2-8f62-24561944dafe",
		"name": "UnitedPaymentTest",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
	},
	"item": [
		{
			"name": "Add",
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n    //Gerçek bilginiz gerekli\r\n    \"name\": \"\",\r\n    //Gerçek bilginiz gerekli\r\n    \"surname\": \"\",\r\n    //Gerçek bilginiz gerekli\r\n    \"birthDate\": \"\",\r\n    //Gerçek bilginiz gerekli\r\n    \"identityNo\": \"\"\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:7144/api/base/add",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "7144",
					"path": [
						"api",
						"base",
						"add"
					]
				}
			},
			"response": []
		},
		{
			"name": "GetByCustomerId",
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:7144/api/base/getCustomer?customerId=",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "7144",
					"path": [
						"api",
						"base",
						"getCustomer"
					],
					"query": [
						{
							"key": "customerId",
							"value": "",
							"description": "Add metodunun döndüğü customerId"
						}
					]
				}
			},
			"response": []
		},
		{
			"name": "GetAllCustomer",
			"request": {
				"method": "POST",
				"header": [],
				"url": {
					"raw": "https://localhost:7144/api/base/allCustomer",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "7144",
					"path": [
						"api",
						"base",
						"allCustomer"
					]
				}
			},
			"response": []
		},
		{
			"name": "Payment",
			"request": {
				"method": "POST",
				"header": [],
				"body": {
					"mode": "raw",
					"raw": "{\r\n    \"transactionId\": \"test123test\",\r\n    \"customerId\": \"1894\",\r\n    \"orderId\": \"test123test\",\r\n    \"type\": \"Auth\",\r\n    \"amount\": \"1,00\",\r\n    \"pan\": \"5406675406675403\",\r\n    \"cvv\": \"000\",\r\n    \"expMonth\": \"12\",\r\n    \"expYear\": \"26\"\r\n}",
					"options": {
						"raw": {
							"language": "json"
						}
					}
				},
				"url": {
					"raw": "https://localhost:7144/api/base/payment",
					"protocol": "https",
					"host": [
						"localhost"
					],
					"port": "7144",
					"path": [
						"api",
						"base",
						"payment"
					]
				}
			},
			"response": []
		}
	]
}
