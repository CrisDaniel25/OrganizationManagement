namespace AdminProSolutions.Domain.Enums
{
    public enum PermissionItem
    {
        #region ADMIN
        Users = 1,
        Groups = 2,
        Tracking = 3,
        Dashboard = 4,
        #endregion

        #region ORGANIZATION
        Clients = 5,
        Employees = 6
        #endregion
    }
}
