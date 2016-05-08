# API Endpoints

## Item

#### Create item

POST: [/api**/item/create**](http://localhost:11704/api/item/create)

*sample body:* <br>
```json
{
    "name":"Mentos Pastiller",
    "description":"m. mint",
    "price":"10.95",
    "tag":"kiosk,pastiller og tyggegummi,pastiller"
}
```

#### Get all items 
GET: [/api**/item/all**](http://localhost:11704/api/item/all)

#### Get item with id
GET: http://localhost:11704/api**/item/4**

#### Update item 

POST: [/api**/item/update**](http://localhost:11704/api/item/update)

*sample body:* <br>
```json
{
    "itemId":22,
    "name":"Mentos Pastiller",
    "description":"m. guld",
    "price":"799.95",
    "tag":"kiosk,pastiller og tyggegummi,pastiller"
}
```

#### Delete item with id

DELETE: [/api**/item/delete/20**](http://localhost:11704/api/item/delete/20)

## User

#### Get all users
GET: [/api**/users**](http://localhost:11704/api/users)

#### Get user by ID
GET: [/api**/users/5**](http://localhost:11704/api/users/5)

#### Update user
PUT: [/api**/users/5**](http://localhost:11704/api/users/5)
*sample body:* <br>
```json
{
    "username":"Kurt",
    "lastname":"Kurtsen",
    "email":"kurt@kurtsen.dk",
    "address":"Smallegade 46A, 2. th., 2000 Frederiksberg"
}
```

#### Create user
POST: [/api**/users**](http://localhost:11704/api/users)
*sample body:* <br>
```json
{
    "username":"Kurt",
    "lastname":"Kurtsen",
    "email":"kurt@kurtsen.dk",
    "address":"Smallegade 46A, 2. th., 2000 Frederiksberg"
}
```
#### Delete user
DELETE: [/api**/users/5**](http://localhost:11704/api/users/5)

## Cart

#### Create cart
POST: [/api**/cart/create/5**](http://localhost:11704/api/cart/create/5)

#### Add item to cart
POST: [/api**/cart/add/4/2/1**](http://localhost:11704/api/cart/add/4/2/1)

#### Get cart by ID
GET: [/api**/cart/get/2**](http://localhost:11704/api/cart/get/2)

#### Get all open carts
GET: [/api**/cart/open**](http://localhost:11704/api/cart/open)

#### Get all closed carts
GET: [/api**/cart/closed**](http://localhost:11704/api/cart/closed)

#### Checkout(close) cart
PUT: [/api**/cart/checkout/2**](http://localhost:11704/api/cart/checkout/2)

#### Update cart item
PUT: [/api**/cart/update/cartitem/2**](http://localhost:11704/api/cart/update/cartiem/2)
```json
{
    "itemId":22,
    "name":"Mentos Pastiller",
    "description":"m. guld",
    "price":"799.95",
    "tag":"kiosk,pastiller og tyggegummi,pastiller"
}
```

#### Delete cart item
DELETE: [/api**/cart/delete/cartitem/4**](http://localhost:11704/api/cart/delete/cartitem/4)

#### Delete cart
DELETE: [/api**/cart/2**](http://localhost:11704/api/cart/2)



