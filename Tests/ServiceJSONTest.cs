namespace Tests
{
    using System;
    using NUnit.Framework;
    using WCFJsonIO;
    using WCFJsonIO.Entities;
    using WCFJsonIO.Services.Contracts;

    [TestFixture]
    public class ServiceJSONTest
    {
        [Test]
        public void Call_MyMethod_With_No_Input_Data(){
            ServiceJSON service = new ServiceJSON();
            ServiceJSONResult response = service.MyMethod(null);
            Assert.True(response.Exception!=null);
        }

        [Test]
        public void Call_MyMethod_With_Input_Data(){
            ServiceJSON service = new ServiceJSON();

            Customer customer = new Customer{
                FirstName = "Steve",
                LastName = "Jobs"
            };

            Account account = new Account{
                UserName = "my_user_name",
                Password = "my_password"
            };
            ServiceJSONInput inputData = new ServiceJSONInput{
                Customer = customer,
                Account = account
            };

            ServiceJSONResult response = service.MyMethod(inputData);

            Assert.True(response.Exception == null);
            Assert.True(response.Customer == customer);
            Assert.True(response.Message !=null);
        }
    }
}
