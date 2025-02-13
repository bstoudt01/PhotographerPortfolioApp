﻿using Microsoft.Data.SqlClient;

namespace AStoudtPhotographyAPI.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString = string.Empty;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
