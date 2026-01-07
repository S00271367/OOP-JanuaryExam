using System;

namespace OOP_JanuaryExam
{
    public class DeliveryRobot : Robot
    {
        public DeliveryMode Mode { get; set; }
        public double MaxPayloadKg { get; set; }

        public DeliveryRobot() : base() { }

        public DeliveryRobot(string name, double capacityKwh, double currentKwh, DeliveryMode mode, double maxPayloadKg)
            : base(name, capacityKwh, currentKwh)
        {
            Mode = mode;
            MaxPayloadKg = maxPayloadKg;
        }

        public string DescribeDelivery()
        {
            return $"Delivery Mode: {Mode}, Max Payload: {MaxPayloadKg} kg";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {DescribeDelivery()}";
        }
    }
}