# ACMEBankWebApi

Based on the models Customer, Account and Transaction api routes will be as below.

GET  
api/customers  
api/accounts  
api/transactions  

GET  
api/customers/{id:int}  
api/accounts/{id:int}  
api/customers/{customerid:int}/accounts
api/transactions/{id:int}
api/accounts/{accountId:int}/transactions

POST  
api/customers  
api/customers/{customer-id}/accounts  
api/accounts/{account-id}/transactions  

PUT  
api/customers/{id:int}  
api/transactions/{id:int}  
api/accounts/{id:int}  

DELETE  
api/customers/{id:int}  
api/transactions/{id:int}  
api/accounts/{id:int}  
