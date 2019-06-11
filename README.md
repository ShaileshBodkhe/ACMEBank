# ACMEBankWebApi

Based on the models Customer, Account and Transaction api routes will be as below.

GET  
api/customers  
api/accounts  
api/transactions  

GET  
api/customers/{id:int}  
api/accounts/{id:int}  
api/transactions/{id:int}  

POST  
api/customers  
api/customers/{customer_id}/accounts  
api/accounts/{account-id}/transactions  

PUT  
api/customers/{id:int}  
api/transactions/{id:int}  
api/accounts/{id:int}  

DELETE  
api/customers/{id:int}  
api/transactions/{id:int}  
api/accounts/{id:int}  
