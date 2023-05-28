# ContosoPizza
## Description:
This is an example of e-pizzaria Asp .NET web API developed with .NET 6 (with mediator and CQRS) and MSSQL.  

## Steps to create an endpoint with mediator pattern: GetPizzaById

  1. Create Request object
  
   ![image](https://github.com/lucass-teixeira/ContosoPizza/assets/54940494/b09c35b6-24a4-486e-ad3a-672f950cc927)
    
  2. Create Response object
  
   ![image](https://github.com/lucass-teixeira/ContosoPizza/assets/54940494/54d75cc1-a93f-4366-9afb-896c3352430f)
    
  4. Create Handler so it has all logic inside
   ![image](https://github.com/lucass-teixeira/ContosoPizza/assets/54940494/d5bce736-d008-4011-a777-bb01bbe2291b)
   
  3. Endpoint: receive request object and handle it with Send() mediator method. 
   ![image](https://github.com/lucass-teixeira/ContosoPizza/assets/54940494/19530bd4-5e09-48a3-b42f-ed8cbbd40f0b)
   

  

    

