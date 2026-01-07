using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_JanuaryExam
{
    public class HouseholdRobot : Robot
    {
        public List<HouseholdSkill> Skills { get; set; } = new List<HouseholdSkill>();

        public HouseholdRobot() : base() { }

        public HouseholdRobot(string name, double capacityKwh, double currentKwh, IEnumerable<HouseholdSkill> skills)
            : base(name, capacityKwh, currentKwh)
        {
            Skills = (skills != null) ? new List<HouseholdSkill>(skills) : new List<HouseholdSkill>();
        }

        public string DescribeSkills()
        {
            return Skills != null && Skills.Any() ? string.Join(", ", Skills) : "No household skills";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Skills: {DescribeSkills()}";
        }
    }
}