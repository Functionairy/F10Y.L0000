using System;


namespace F10Y.L0000
{
    public class MachineNameOperator : IMachineNameOperator
    {
        #region Infrastructure

        public static IMachineNameOperator Instance { get; } = new MachineNameOperator();


        private MachineNameOperator()
        {
        }

        #endregion
    }
}
