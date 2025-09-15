using System;


namespace F10Y.L0000
{
    public class OrderOperator : IOrderOperator
    {
        #region Infrastructure

        public static IOrderOperator Instance { get; } = new OrderOperator();


        private OrderOperator()
        {
        }

        #endregion
    }
}
