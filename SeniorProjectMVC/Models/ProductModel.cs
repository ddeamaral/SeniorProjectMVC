using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SeniorProjectMVC.Models
{
    public class ProductModel
    {
        #region Constructors

        
        public ProductModel()
        {

        }
                
        public ProductModel(int productid)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.CommandText = "[Product_SelectByProductID]";
                comm.Parameters.AddWithValue("@ProductID", productid);

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable data_tbl = new DataTable();
                adapter.Fill(data_tbl);
                adapter.Dispose();
            }
        }

        #endregion

        #region Properties
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = 0; }
        }

        private string _Name;
        public string Name
        {
            get { return Name; }
            set { if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Must have a product name");
                    } else { _Name = value; } }
        }

        private string _Code;
        public string Code { get { return _Code } set { _Code = value; } }

        private string _Description;
        public string Description { get { return _Description; } set { _Description = value; } }

        private string _CategoryID;
        public string CategoryID { get { return _CategoryID; } set { _CategoryID = value; } }




        #endregion


        private bool SaveProduct(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.StoredProcedure;
                if (product.ID > 0)
                    comm.CommandText = "Product_Insert";
                else
                    comm.CommandText = "Product_Update";

                comm.Parameters.AddWithValue("@ID", product.ID);
                

            }
                


        }

        private ProductModel PopulateProduct(DataRow dr)
        {
            var productModel = new ProductModel();
            productModel.ID = (int)dr["ProductID"];

            return productModel;
        }
    }
}