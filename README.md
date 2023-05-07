# erudio-microservices-dotnet6




comandos workbench

=====================================================
CART_HEADER
SELECT * FROM 2_geek_shopping_cart_api.cart_header;

delete FROM 2_geek_shopping_cart_api.cart_header
where id != 	'1';

 =====================================================
CART_DETAILS
SELECT * FROM 2_geek_shopping_cart_api.cart_details;

=====================================================
CART_PRODUCT
SELECT * FROM 2_geek_shopping_cart_api.product;

DELETE FROM 2_geek_shopping_cart_api.product
WHERE id != 1;




Rabbit MQ Anotações


#Imagem docker com um gerenciador

docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management

#url local para acesso

http://127.0.0.1:15672/

