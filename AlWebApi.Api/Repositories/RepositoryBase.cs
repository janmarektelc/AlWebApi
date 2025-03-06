using Microsoft.EntityFrameworkCore;

namespace AlWebApi.Api.Repositories
{
    /// <summary>
    /// Base repository class.
    /// </summary>
    public abstract class RepositoryBase<T> where T : DbContext, IDisposable
    {
        /// <summary>
        /// Application database context;
        /// </summary>
        protected T DbContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the repository class.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        public RepositoryBase(T dbContext)
        {
            this.DbContext = dbContext;
        }

        /// <summary>
        /// Saves all changes made in the database context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public int SaveChanges()
        {
            return this.DbContext.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves all changes made in the database context to the database.
        /// </summary>
        /// <param name="cancellationToken">Cancelation token.</param>
        /// <returns>The number of state entries written to the database.</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await this.DbContext.SaveChangesAsync(cancellationToken);
        }

        private bool disposed = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
