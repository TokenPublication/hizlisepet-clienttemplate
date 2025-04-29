# HizliSepet Client Template

## Overview

HizliSepet Client Template is a .NET application that serves as a client interface for integrating with Point of Sale (POS) devices through the "TokenX Connect (Wired)" or "Integration Hub" middleware. This application facilitates seamless communication between retail/business software and physical POS terminals.

## Key Features

1. **POS Device Communication**: Establishes and maintains connections with POS hardware devices via the Integration Hub.
2. **Basket Management**: Creates, modifies, and submits shopping baskets to POS devices with full control of item details, pricing, and taxation.
3. **Payment Processing**: Handles various payment methods (cash, card) with real-time transaction feedback.
4. **Fiscal Information**: Retrieves and displays fiscal data from connected POS devices, including product lookup tables and business sections.
5. **Advanced Operations**: Supports specialized transactions such as:
   - Advances
   - Invoice payments 
   - Current account collections
   - Invoice information receipts
   - E-invoice information receipts
   - E-archive invoice information receipts

## Architecture

The application follows a modular design with the following components:

### Core Components

- **MainForm (Form1.cs)**: The primary UI form that handles user interactions and displays results.
- **Basket.cs**: Contains data models for the shopping basket, items, customer information, and payment details.
- **FiscalInfo.cs**: Defines structures for fiscal data from POS devices (PLUs, sections, etc.).
- **ReceiptInfo.cs**: Models for receipt data returned after payment transactions.

### Integration Approach

- Uses a callback-based approach for asynchronous communication with POS devices
- Serializes/deserializes data using JSON for cross-platform compatibility
- Implements a rich UI for basket and payment management

## Data Models

### Basket

The central data structure containing:
- Basket metadata (ID, document type, etc.)
- List of items with price, tax, and quantity information
- Customer information
- Payment details
- Adjustment information (discounts/surcharges)

### Items

Product entries that can be added to a basket, containing:
- Product identification (barcode, name, PLU number)
- Pricing information
- Tax categorization
- Quantity

### Fiscal Information 

POS device configuration including:
- Business mode
- Product lookup entries (PLUs)
- Business sections with tax rates
- Receipt limits

### Receipt Information

Transaction results containing:
- Receipt identification
- Payment items
- Status information
- Fiscal reporting data

## Communication Flow

1. **Device Connection**: Application establishes connection with POS device via Integration Hub
2. **Fiscal Data Retrieval**: Downloads available product and section information
3. **Basket Creation**: User constructs a basket with items, payments, and customer details
4. **Basket Submission**: Sends the basket to POS for processing
5. **Payment Processing**: Handles payment through the POS device
6. **Receipt Generation**: Receives and displays transaction results

## Special Transaction Types

The application supports various document types through specialized forms:
- **Advance Payments** (9000): Records advance payments with customer details
- **Invoice Collections** (9001): Processes payments against existing invoices
- **Current Account Collections** (9002): Handles collections from customer accounts
- **Invoice Information Receipts** (9005/9006/9007): Creates receipts with invoice references

## Requirements

- .NET Framework
- Newtonsoft.Json library for JSON serialization
- Integration Hub middleware for POS communication

## Usage

1. Connect to a POS device via the Integration Hub
2. Retrieve fiscal information (sections and products)
3. Create a basket by adding items from available sections or products
4. Add customer information if needed
5. Configure payment methods
6. Submit the basket to the POS for processing
7. Review transaction results

