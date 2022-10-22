# Auth
This service is intended for the consciousness and verification of JWT.

<h2>Methods</h2>

| Method name | Request type | Desciption |
| ----------- | ------------ | ---------- |
| GetToken | POST | Creates a JWT for a specific user |
| Check-token | GET | Checks the viability of JWT |

<h2>Ways to start the service</h2>

<h3>docker-compose</h3>

Go to the ./devops directory and run next command:

```
docker-compose up
```

After starting the container, you can send a request to the service and get your JWT.

Request JWT url:

```
POST: http://localhost:81/api/Auth?userName=admin&password=admin
```

Save JWT issued to you.

Now you can verify JWT. To do this, you need to send a request. Insert the previously saved token into the request authorization header.

```
GET: http://localhost:81/api/Auth/Check-token
```

<h3>Normal startup</h3>

After building the project, run it. After a successful launch, you can send a request to the service to receive JWT.

```
POST: http://your_url/api/Auth?userName=admin&password=admin
```

Save JWT issued to you.

Now you can verify JWT. To do this, you need to send a request. Insert the previously saved token into the request authorization header.

```
GET: http://your_url/api/Auth/Check-token
```
