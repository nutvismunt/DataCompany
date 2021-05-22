namespace DataCompany.Interfaces
{
    public interface IPath
    {
        /// <summary>
        /// path to database
        /// </summary>
        string GetDbPath(string dbname);
    }
}
