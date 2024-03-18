namespace Scripts.GameSystem.LevelGeneration.Grid
{
    public class TypeConnectionForCell
    {
        public TypeConnection ForwardConnection;
        public TypeConnection RightConnection;
        public TypeConnection LeftConnection;

        public int NeedConnectCount;
        public int MaxConnectCount;

        public TypeConnectionForCell(TypeConnection forwardConnection, TypeConnection rightConnection, TypeConnection leftConnection)
        {
            ForwardConnection = forwardConnection;
            RightConnection = rightConnection;
            LeftConnection = leftConnection;

            NeedConnectCount = MaxConnectCount = 0;

            CountConnect(ForwardConnection);
            CountConnect(RightConnection);
            CountConnect(LeftConnection);
        }

        private void CountConnect(TypeConnection typeConnection)
        {
            if (typeConnection == TypeConnection.NeededForConnect)
            {
                NeedConnectCount++;
                MaxConnectCount++;
            }
            if (typeConnection == TypeConnection.FreeForConnect)
                MaxConnectCount++;
        }

        public override string ToString()
        {
            return string.Format("ForwardConnection:" + ForwardConnection.ToString() +
                                 "\nRightConnection:" + RightConnection.ToString() +
                                 "\nLeftConnection:" + LeftConnection.ToString() +
                                 "\nNeedConnectCount:" + NeedConnectCount +
                                 "\nMaxConnectCount:" + MaxConnectCount);
        }
    }
}
