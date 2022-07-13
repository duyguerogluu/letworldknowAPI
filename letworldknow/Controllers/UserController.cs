using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace letworldknow.Controllers
{
    public class UserController : ApiController
    {
        public string GetLogin(string username, string password)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select user_key from [user] where " +
                            "(username='" + username + "') and " +
                            "(password='" + password + "')", con);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            return dataTable.Rows[0].ItemArray[0].ToString();
                        }
                        else
                        {
                            return "0";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "0";
            }

        }

        public string GetRegister(string id, string username, string password, string status, string phone, string email, string adress, string creation_date, string location, string birthday, string gender, string relationship_status, string job, string user_photo_name, string user_type_id)

        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        try
                        {
                            SqlConnection FDataConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi"].ToString());
                            FDataConnect.Open();
                            SqlDataAdapter FDataAdapter = new SqlDataAdapter(string.Format("select username from [user] where rtrim(username) = '" + username.Trim() + "'"), FDataConnect);
                            DataTable dataTable = new DataTable();
                            FDataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                return dataTable.Rows[0].ItemArray[0].ToString().Trim() + " kullanıcı adı alındı...";
                            }
                            else
                            {
                                if (id == "0")
                                {
                                    try
                                    {
                                        String APIKey;
                                        using (var cryptoProvider = new RNGCryptoServiceProvider())
                                        {
                                            byte[] secretKeyByteArray = new byte[32];
                                            cryptoProvider.GetBytes(secretKeyByteArray);
                                            APIKey = Convert.ToBase64String(secretKeyByteArray);
                                        }
                                        using (SqlCommand cmd = new SqlCommand("insert into [user] (username,password,status,phone,email,adress,creation_date,location,birthday,gender,relationship_status,job,user_photo_name,user_key,user_type_id) values (@username,@password,@status,@phone,@email,@adress,@creation_date,@location,@birthday,@gender,@relationship_status,@job,@user_photo_name,@user_key,@user_type_id)", con))
                                        {
                                            cmd.Parameters.AddWithValue("@username", username);
                                            cmd.Parameters.AddWithValue("@password", password);
                                            cmd.Parameters.AddWithValue("@status", status);
                                            cmd.Parameters.AddWithValue("@phone", phone);
                                            cmd.Parameters.AddWithValue("@email", email);
                                            cmd.Parameters.AddWithValue("@adress", adress);
                                            cmd.Parameters.AddWithValue("@creation_date", creation_date);
                                            cmd.Parameters.AddWithValue("@location", location);
                                            cmd.Parameters.AddWithValue("@birthday", birthday);
                                            cmd.Parameters.AddWithValue("@gender", gender);
                                            cmd.Parameters.AddWithValue("@relationship_status", relationship_status);
                                            cmd.Parameters.AddWithValue("@job", job);
                                            cmd.Parameters.AddWithValue("@user_photo_name", user_photo_name);
                                            cmd.Parameters.AddWithValue("@user_key", APIKey);
                                            cmd.Parameters.AddWithValue("@user_type_id", user_type_id);
                                            int i = cmd.ExecuteNonQuery();
                                            con.Close();
                                            if (i == 1)
                                                return "Kayıt eklendi";
                                            else
                                                return "Kayıt eklenemedi";
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return "Kayıt eklenemedi";
                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        using (SqlCommand cmd = new SqlCommand("update [user] set username=@username, password=@password, status=@status, phone=@phone, email=@email, adress=@adress,  creation_date=@creation_date, location=@location, birthday=@birthday, gender=@gender, relationship_status=@relationship_status, job=@job, user_photo_name=@user_photo_name, user_key=@user_key, user_type_id=@user_type_id  where id=@id", con))
                                        {
                                            cmd.Parameters.AddWithValue("@id", id);
                                            cmd.Parameters.AddWithValue("@username", username);
                                            cmd.Parameters.AddWithValue("@password", password);
                                            cmd.Parameters.AddWithValue("@status", status);
                                            cmd.Parameters.AddWithValue("@phone", phone);
                                            cmd.Parameters.AddWithValue("@email", email);
                                            cmd.Parameters.AddWithValue("@adress", adress);
                                            cmd.Parameters.AddWithValue("@creation_date", creation_date);
                                            cmd.Parameters.AddWithValue("@location", location);
                                            cmd.Parameters.AddWithValue("@birthday", birthday);
                                            cmd.Parameters.AddWithValue("@gender", gender);
                                            cmd.Parameters.AddWithValue("@relationship_status", relationship_status);
                                            cmd.Parameters.AddWithValue("@job", job);
                                            cmd.Parameters.AddWithValue("@user_photo_name", user_photo_name);
                                            cmd.Parameters.AddWithValue("@user_type_id", user_type_id);
                                            int i = cmd.ExecuteNonQuery();
                                            con.Close();
                                            if (i == 1)
                                                return "Güncellendi";
                                            else
                                                return "Güncellenemedi";
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return "Güncellenemedi";
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            return "Hatalı kullanıcı adı girdiniz";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "İşlem başarısız";
            }

        }

        public string GetPasswordReset(string id, string oldpassword, string newpassword)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["webapi"].ConnectionString;
                using (
                    SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    {
                        try
                        {
                            SqlConnection FDataConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi"].ToString());
                            FDataConnect.Open();
                            SqlDataAdapter FDataAdapter = new SqlDataAdapter(string.Format("select password from [user] where id=" + id), FDataConnect);
                            DataTable dataTable = new DataTable();
                            FDataAdapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                if (dataTable.Rows[0].ItemArray[0].ToString() == oldpassword) //eski şifreyle veri tabanındaki şifre aynı ise
                                {
                                    using (SqlCommand cmd = new SqlCommand("update [user] set password=@password where id=@id", con))
                                    {
                                        cmd.Parameters.AddWithValue("@id", id);
                                        cmd.Parameters.AddWithValue("@password", newpassword);
                                        int i = cmd.ExecuteNonQuery();
                                        con.Close();
                                        if (i == 1)
                                            return "Şifre güncellendi";
                                        else
                                            return "Şifre güncellenemedi";
                                    }
                                }
                                else
                                {
                                    return "Eski şifrenizi yanlış girdiniz";
                                }
                            }
                            else
                            {
                                return "Bu kullanıcı bulunamadı";
                            }
                        }
                        catch (Exception)
                        {
                            return "Şifre yenilenemedi";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "İşlem başarısız";
            }

        }

    }
}
