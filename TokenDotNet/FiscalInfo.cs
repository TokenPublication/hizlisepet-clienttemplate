/*
 * FiscalInfo.cs
 * 
 * This file contains data models for fiscal information used in the TokenX Connect (Wired) / Integration Hub
 * POS device integration. Written in C# for .NET, these classes provide the structure for storing and
 * managing fiscal business information such as product lookup (PLU) data, business sections, pricing,
 * and tax information.
 * 
 * The models defined here serve as the bridge between the application and the POS device,
 * enabling the system to send structured fiscal data for receipt generation, inventory management,
 * and sales reporting.
 * 
 * Platform: .NET (C#)
 * Integration: TokenX Connect (Wired) / Integration Hub
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenDotNet
{
    /// <summary>
    /// Represents the fiscal configuration and data for a business using the POS system.
    /// Contains information about business mode, product lookup entries, receipt limits,
    /// and business sections required for fiscal operations.
    /// </summary>
    internal class FiscalInfo
    {
        /// <summary>
        /// Defines the operation mode of the business (e.g., retail, restaurant, etc.)
        /// </summary>
        public int businessMode { get; set; }
        
        /// <summary>
        /// The total number of Product Look-Up entries in the system
        /// </summary>
        public int pluCount { get; set; }
        
        /// <summary>
        /// Collection of Product Look-Up entries for products/services offered by the business
        /// </summary>
        public List<Plus> plus { get; set; }
        
        /// <summary>
        /// Defines limits for receipts (e.g., maximum amount, daily transaction count)
        /// </summary>
        public object receiptLimit { get; set; }
        
        /// <summary>
        /// The total number of business sections/departments
        /// </summary>
        public int sectionCount { get; set; }
        
        /// <summary>
        /// Collection of business sections/departments
        /// </summary>
        public List<Section> sections { get; set; }
    }

    /// <summary>
    /// Represents a Product Look-Up (PLU) entry in the POS system.
    /// Contains detailed information about a product including pricing, tax information,
    /// barcode, and categorization data needed for sales and inventory management.
    /// </summary>
    internal class Plus
    {
        /// <summary>
        /// Barcode identifier for the product
        /// </summary>
        public string barcode { get; set; }
        
        /// <summary>
        /// Display name of the product
        /// </summary>
        public string name { get; set; }
        
        /// <summary>
        /// Unique numeric identifier for the PLU entry
        /// </summary>
        public int pluNo { get; set; }
        
        /// <summary>
        /// Price of the product in the smallest currency unit (e.g., cents)
        /// </summary>
        public int price { get; set; }
        
        /// <summary>
        /// Business section/department number that this product belongs to
        /// </summary>
        public int sectionNo { get; set; }
        
        /// <summary>
        /// Tax percentage applied to this product
        /// </summary>
        public int taxPercent { get; set; }
        
        /// <summary>
        /// Type of product (e.g., normal, service, discount)
        /// </summary>
        public int type { get; set; }
        
        /// <summary>
        /// Unit of measurement for the product (e.g., piece, kg, L)
        /// </summary>
        public string unit { get; set; }
        
        /// <summary>
        /// VAT (Value Added Tax) identifier for tax reporting
        /// </summary>
        public int vatID { get; set; }
    }

    /// <summary>
    /// Represents a business section or department in the POS system.
    /// Sections are used to categorize products, apply different tax rates,
    /// and generate reports based on department performance.
    /// </summary>
    internal class Section
    {
        /// <summary>
        /// Maximum transaction limit for this section
        /// </summary>
        public int limit { get; set; }
        
        /// <summary>
        /// Name of the business section/department
        /// </summary>
        public string name { get; set; }
        
        /// <summary>
        /// Price of the product in the smallest currency unit (e.g., cents)
        /// </summary>
        public int price { get; set; }
        
        /// <summary>
        /// Business section/department number
        /// </summary>
        public int sectionNo { get; set; }
        
        /// <summary>
        /// Tax percentage applied to this section
        /// </summary>
        public int taxPercent { get; set; }
        
        /// <summary>
        /// Type of section (e.g., normal, service, discount)
        /// </summary>
        public int type { get; set; }
    }
}
