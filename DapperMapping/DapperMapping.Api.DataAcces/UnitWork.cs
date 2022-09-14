using Microsoft.Data.SqlClient;
using System.Data;
using DapperMapping.Api.DataAcces.Repository;
using DapperMapping.Api.Models;
using DapperMapping.Api.DataAcces.CustomColumnAttribute;

namespace DapperMapping.Api.DataAcces
{
    public class UnitWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        private IContactsRepository _contactrepository;
        public UnitWork()
        {
            //First fix
            //Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
             InitCustomColumn();
             _connection = new SqlConnection("Server=localhost;Database=learn;Trusted_Connection=true;TrustServerCertificate=Yes;");
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void InitCustomColumn()
        {
            Dapper.SqlMapper.SetTypeMap(typeof(Contacts), new ColumnAttributeTypeMapper<Contacts>());
        }

        public IContactsRepository ContactsRepository
        {
            get { return _contactrepository ?? (_contactrepository = new ContactsRepository(_transaction)); }
        }


        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
         /*   _breedRepository = null;
            _catRepository = null;*/
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitWork()
        {
            dispose(false);
        }
    }
}