using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ProyecTitulacion.Model;

using System.Web;
using RestSharp;

namespace ProyecTitulacion.Functions
{
    public static class Services
    {
        private static string server = "https://picaditas.azurewebsites.net/";
        //private static string server= "https://192.168.100.12:44379/";

        private static string UrlServicioTblMember =server+ "api/TblMembers/";
        public static Retorno MantenimientoLogIn(
            string ai_codOp,
            int ai_MemberId,
            string ai_FirstName,
            string ai_LastName,
            string ai_EmailId,
            string ai_Password,
            bool ai_IsActive,
            bool ai_IsDelete,
            DateTime ai_CreatedOn,
            DateTime ai_ModifiedOn)
        {
            var client = new RestClient(UrlServicioTblMember);
            //client.UseJson();
           
            // "https://picaditasfoodcommerce.azurewebsites.net/api/TblMember/MantenimientoTblMember");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("email", ai_EmailId);
            request.AddParameter("password", ai_Password);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            List<TblMembers> members = new List<TblMembers>();
             
            try
            {
                
                Retorno retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                retorno.procesoCorrecto = true;
                retorno.mensaje = "";
                TblMembers miembro = JsonConvert.DeserializeObject<TblMembers>(retorno.retorno.ToString());
                retorno.retorno = miembro;
                return retorno;
            }
            catch(JsonException ex)
            {
                return null;
            }
            
        }


        public static bool RegistraUsuario(TblMembers Usuario, FileParameter Archivo)
        {
            try
            {
                var client = new RestClient(UrlServicioTblMember);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(Usuario);
                RestResponse response = (RestResponse)client.Execute(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return false;
                }
                List<TblMembers> members = new List<TblMembers>();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //TblRoles
        public static List<TblRoles> MantenimientoRoles(
            string ai_codOp,
             int ai_RoleId,
             string ai_RoleName)
        {
            var client = new RestClient("https://picaditasfoodcommerce.azurewebsites.net/api/TblRoles/MantenimientoTblRoles");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"operacionCod\": \"" + ai_codOp + "\",\r\n  \"roleId\": " + ai_RoleId + "\r\n  \"roleName\": \""+ ai_RoleName+"\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<TblRoles> roles = new List<TblRoles>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                roles = JsonConvert.DeserializeObject<List<TblRoles>>(retorno.retorno.ToString());

            }
            catch
            {

            }
            return roles;
        }


        //TblCart
        public static List<TblCart> MantenimientoCart(
             string ai_codOp,
             int ai_CartId,
             string ai_MemberId,              
             string ai_CartStatusId)
        {
            var client = new RestClient("https://picaditasfoodcommerce.azurewebsites.net/api/TblCart/MantenimientoTblCart");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"operacionCod\": \"" + ai_codOp + "\",\r\n  \"cartId\": " + ai_CartId + ",\r\n  \"memberId\": " + ai_MemberId + ",\r\n  \"cartStatusId\": " + ai_CartStatusId + "\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<TblCart> Cart = new List<TblCart>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                Cart = JsonConvert.DeserializeObject<List<TblCart>>(retorno.retorno.ToString());


            }
            catch
            {

            }
            return Cart;
        }

        //TblCartDetail
        public static List<TblCartDetail> MantenimientoCartDetail(
            string ai_codOp,
            int ai_CartDetailId,
            string ai_CartId,
            string ai_ProductId,
            string ai_CartStatusId)
        {
            var client = new RestClient("https://picaditasfoodcommerce.azurewebsites.net/api/TblCartDetail/MantenimientoTblCartDetail");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"operacionCod\": \"" + ai_codOp + "\",\r\n  \"cartDetailId\": " + ai_CartDetailId + ",\r\n  \"cartId\": " + ai_CartId + ",\r\n  \"productId\": " + ai_ProductId + ",\r\n  \"cartStatusId\": " + ai_CartStatusId + "\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<TblCartDetail> CartDetail = new List<TblCartDetail>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                CartDetail = JsonConvert.DeserializeObject<List<TblCartDetail>>(retorno.retorno.ToString());


            }
            catch
            {

            }
            return CartDetail;
        }

        //TblCartStatus
        public static List<TblCartStatus> MantenimientoCartStatus(
            string ai_codOp,
            int ai_CartStatusId,
            string ai_CartStatus)
        {
            var client = new RestClient("https://picaditasfoodcommerce.azurewebsites.net/api/TblCartStatus/MantenimientoTblCartStatusController");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"operacionCod\": \"" + ai_codOp + "\",\r\n  \"cartStatusId\": " + ai_CartStatusId + ",\r\n  \"cartStatus\": \"" + ai_CartStatus + "\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<TblCartStatus> CartStatus = new List<TblCartStatus>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                CartStatus = JsonConvert.DeserializeObject<List<TblCartStatus>>(retorno.retorno.ToString());

            }
            catch
            {

            }
            return CartStatus;
        }

        //TblCategory
        public static List<TblCategory> MantenimientoCategory(
            string ai_codOp,
            int ai_CategoryId,
            string ai_CategoryName,
            bool ai_IsActive,
            bool ai_IsDelete)
        {
            var client = new RestClient("https://picaditasfoodcommerce.azurewebsites.net/api/TblCategory/MantenimientoTblCategory");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"operacionCod\": \"" + ai_codOp + "\",\r\n  \"categoryId\": " + ai_CategoryId + ",\r\n  \"categoryName\": \"" + ai_CategoryName + "\",\r\n  \"isActive\": " + ai_IsActive + ",\r\n  \"isDelete\": " + ai_IsDelete + "\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<TblCategory> Category = new List<TblCategory>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                Category = JsonConvert.DeserializeObject<List<TblCategory>>(retorno.retorno.ToString());


            }
            catch
            {

            }
            return Category;
        }

        //TblMemberRole
        public static List<TblMemberRole> MantenimientoMemberRole(
            string ai_codOp,
            int ai_MemberRoleID,
            string ai_memberId,
            string ai_RoleId)
        {
            var client = new RestClient("https://picaditasfoodcommerce.azurewebsites.net/api/TblMemberRole/MantenimientoTblMemberRole");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"operacionCod\": \"" + ai_codOp + "\",\r\n  \"memberRoleID\": " + ai_MemberRoleID + ",\r\n  \"memberId\": " + ai_memberId + ",\r\n  \"roleId\": " + ai_RoleId + "\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<TblMemberRole> MemberRole = new List<TblMemberRole>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                MemberRole = JsonConvert.DeserializeObject<List<TblMemberRole>>(retorno.retorno.ToString());

            }
            catch
            {

            }
            return MemberRole;
        }

        //TblProduct
        public static Retorno MantenimientoGetProducts()
        {
            var client = new RestClient(server+"/api/TblProduct/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
           
            IRestResponse response = client.Execute(request); 

            List<TblProduct> Product = new List<TblProduct>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                if (retorno.retorno.ToString().Length > 0)
                {
                    retorno.retorno = JsonConvert.DeserializeObject<TblProduct>(retorno.retorno.ToString());
                }
            }
            catch
            {

            }
            return retorno;
        }

        //TblSlideImage
        public static List<TblSlideImage> MantenimientoSlideImage(
            string ai_codOp,
            int ai_SlideId,
            string ai_SlideTitle,
            string ai_SlideImage)
        {
            var client = new RestClient("https://picaditasfoodcommerce.azurewebsites.net/api/TblSlideImage/MantenimientoblSlideImage");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n  \"operacionCod\": \"" + ai_codOp + "\",\r\n  \"slideId\": " + ai_SlideId + ",\r\n  \"slideTitle\": " + ai_SlideTitle + ",\r\n  \"slideImage\": " + ai_SlideImage + "\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            List<TblSlideImage> SlideImage = new List<TblSlideImage>();
            Retorno retorno = new Retorno();
            try
            {
                retorno = JsonConvert.DeserializeObject<Retorno>(response.Content);
                SlideImage = JsonConvert.DeserializeObject<List<TblSlideImage>>(retorno.retorno.ToString());

            }
            catch
            {

            }
            return SlideImage;
        }
    }
}
