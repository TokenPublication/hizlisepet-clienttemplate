/*
 * TokenDotNet - InfoReceiptInfo.cs
 * 
 * This C# class is part of the TokenX Connect (Wired) / Integration Hub system
 * that facilitates communication with point-of-sale (POS) devices. The class
 * represents receipt information that can be exchanged between the client 
 * application and the POS device during transaction processing.
 * 
 * Platform: .NET
 * Language: C#
 * 
 * This model class is used to structure and standardize the receipt information
 * format within the integration layer, ensuring consistent data handling when
 * communicating with the POS hardware through the TokenX Connect interface.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenDotNet
{
    /// <summary>
    /// Represents the receipt information structure for POS transactions.
    /// This class encapsulates the key details that appear on a receipt
    /// such as document numbers, dates, subscriber information and identifiers.
    /// Used within the TokenX Connect/Integration Hub system for POS integration.
    /// </summary>
    public class InfoReceiptInfo
    {
        /// <summary>
        /// Gets or sets the document number which uniquely identifies the transaction receipt.
        /// </summary>
        public string documentNo { get; set; }

        /// <summary>
        /// Gets or sets the date of the document/receipt in a string format.
        /// </summary>
        public string documentDate { get; set; }

        /// <summary>
        /// Gets or sets the subscriber number identifying the customer or account associated with the transaction.
        /// </summary>
        public string subscriberNo { get; set; }

        /// <summary>
        /// Gets or sets the name of the company/merchant that issued the receipt.
        /// </summary>
        public string companyName { get; set; }

        /// <summary>
        /// Gets or sets the serial number of the POS device or the receipt itself.
        /// This typically serves as an additional identifier for tracking or verification purposes.
        /// </summary>
        public string serialNo { get; set; }
    }
}
