#API Endpoints

##Item

####Create item

POST: [http://localhost:11704/api**/item/create**](http://localhost:11704/api/item/create)

*sample body:* <br>
```json
{
    "name":"Mentos Pastiller",
    "description":"m. mint",
    "price":"10.95",
    "tag":"kiosk,pastiller og tyggegummi,pastiller"
}
```

####get all items 
GET: [http://localhost:11704/api**/item/all**](http://localhost:11704/api/item/all)

####get item with id
GET: http://localhost:11704/api**/item/4**

####update item 

POST: [http://localhost:11704/api**/item/update**](http://localhost:11704/api/item/update)

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

####delete item with id

DELETE: [http://localhost:11704/api**/item/delete/20**](http://localhost:11704/api/item/delete/20)

##User

##Cart