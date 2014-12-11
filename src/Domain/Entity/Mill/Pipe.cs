﻿using System;
using Domain.Entity.Setup;
using System.Collections.Generic;
using Domain.Entity.Construction;

namespace Domain.Entity.Mill
{
    public class Pipe : PipelinePiece
    {
        public Pipe()
        {
            this.Welds = new List<Weld>();
            this.Coats = new List<Coat>();
            this.Spools = new List<Spool>();
            this.PipeTestResult = new List<PipeTestResult>();

            this.Plate = new Plate() { Pipe = this };
        }

        public virtual Plate Plate { get; set; }

        public virtual string Mill { get; set; }
        public virtual int Diameter { get; set; }
        public virtual int WallThickness { get; set; }

        public virtual float Weight { get; set; }

        public virtual DateTime ProductionDate { get; set; }

        public virtual PipeMillSizeType Type { get; set; }

        public virtual Railcar Railcar { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual ChemicalComposition ChemicalComposition { get; set; }

        public virtual IList<Weld> Welds { get; set; }
        public virtual IList<PipeTestResult> PipeTestResult { get; set; }
        public virtual IList<Coat> Coats { get; set; }

        public virtual IList<Spool> Spools { get; set; }

        public virtual PipeMillStatus Status { get; set; }

        /// <summary>
        ///  Density of carbon steel
        /// </summary>
        public const float Ro = 0.00000785F;

        /// <summary>
        ///  Density of carbon steel
        /// </summary>
        /// <param name="WallThickness"> Pipe WallThickness</param>
        ///  <param name="Diameter"> Pipe Diameter</param>
        ///  <param name="Length"> Pipe Length</param>
        public static float ChangePipeWeight(int WallThickness, int Diameter, int Length )
        {
            return (float)(Math.PI * Ro * WallThickness * (Diameter - WallThickness) * Length);
        }

    }
}