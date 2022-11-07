import React, { Component } from 'react';

export class Vending extends Component {
    static displayName = Vending.name;

    constructor(props) {
        super(props);
        this.state = {
            products: [],
            invoice: [],
            invoiceItems: [],
            paymentData: [],
            totalProducts: 0,
            totalDue: 0.00,
            loading: true,
            sodaProductCounter: 0,
            candyProductCounter: 0,
            chipsProductCounter: 0,
            sodaInvoiceCounter: 0,
            candyInvoiceCounter: 0,
            chipsInvoiceCoutner: 0
        };
        // calls the function to populate the static products list.
        this.getAllProducts();

        // binds the functions for use with buttons to add products to the shopping cart.
        this.sodaIncrementCounter = this.sodaIncrementCounter.bind(this);
        this.candyIncrementCounter = this.candyIncrementCounter.bind(this);
        this.chipsIncrementCounter = this.chipsIncrementCounter.bind(this);


        // binds the functions for use with buttons to remove products from shopping cart.
        this.sodaDecrementCounter = this.sodaDecrementCounter.bind(this);
        this.candyDecrementCounter = this.candyDecrementCounter.bind(this);
        this.chipsDecrementCounter = this.chipsDecrementCounter.bind(this);
    }

    // at start, populates the static products list.
    componentDidMount() {
        this.getAllProducts();
    }

    // used to add item to shopping cart.
    sodaIncrementCounter() {
        this.setState({
            sodaCounter: this.state.sodaCounter + 1
        });
    }
    candyIncrementCounter() {
        this.setState({
            candyCounter: this.state.candyCounter + 1
        });
    }
    chipsIncrementCounter() {
        this.setState({
            chipsCounter: this.state.chipsCounter + 1
        });
    }

    // used to remove item from shopping cart.
    sodaDecrementCounter() {
        this.setState({
            sodaCounter: this.state.sodaCounter + 1
        });
    }
    candyDecrementCounter() {
        this.setState({
            candyCounter: this.state.candyCounter + 1
        });
    }
    chipsDecrementCounter() {
        this.setState({
            chipsCounter: this.state.chipsCounter + 1
        });
    }

    // used to update the number of products when add/remove products.
    totalProductsCalculator() {
        this.setState({
            totalProducts: this.state.sodaInvoiceCounter + this.state.candyInvoiceCounter + this.state.chipsInvoiceCoutner
        })
    }

    // used to update the total cost of products when add/remove products.
    totalDueCalculator() {
        this.setState({
            todalDue: this.sodaCalculatedTotal + this.candyCalculatedTotal + this.chipsCalculatedTotal
        })
    }

    // creates the products table
    static renderProductsTable(products) {
        return (
            <table id='productTable' className='table table-stripped' aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th></th>
                        <th>Products</th>
                        <th>Cost</th>
                        <th>Qty</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product =>
                        <tr key={product.name}>
                            <td><button className="btn btn-primary" onClick={getAddButtonOnClick(product)}>Add</button></td>
                            <td>{product.name}</td>
                            <td>{product.cost}</td>
                            <td>{product.quantity}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    // creates the invoice table
    static renderInvoiceTable(invoice) {
        return (
            <div>
                {this.invoiceItemContents }
                <p>
                    <label>Total Due: </label>
                    <label style={{ marginRight: '10px', width: '100px'} }>{invoice.InvoiceTotal}</label>

                    <label>Total Products: </label>
                    <label style={{ width: '100px'} }>{invoice.ProductTotal}</label>
                </p>
            </div>
        );
    }

    // creates the invoice items table.
    static renderInvoiceItemTable(invoiceItems) {
        return (
            <div>
                <table id='invoiceItemTable' className='table table-stripped' aria-labelledby="tableLabel">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Products</th>
                            <th>Qty</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        {invoiceItems.map(invoiceItem =>
                            <tr key={invoiceItem.productName}>
                                <td><button className="btn btn-primary" onClick={getRemoveButtonOnClick(invoiceItem.name)}>Remove</button></td>
                                <td>{invoiceItem.productName}</td>
                                <td>{invoiceItem.quantity}</td>
                                <td>{invoiceItem.itemtotal}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    // creates the payment section
    static renderPaymentTable(paymentData) {
        return (
            <div>
                <p>
                    <label>Name On Card: </label>
                    <input style={{ marginRight: '10px' }}>{paymentData.NameOnCard}</input>

                    <label>Credit Card Number: </label>
                    <input>{paymentData.CreditCardNumber}</input>
                </p>

                <p>
                    <label>Expiration: </label>
                    <input style={{ marginRight: '10px' }}>{paymentData.CreditCardExpiration}</input>

                    <label>CVV: </label>
                    <input>{paymentData.CreditCardCVV}</input>
                </p>

                <p>
                    <label>Status: </label>
                    <input>{paymentData.TransactionStatus}</input>
                </p>

                <p>
                </p>

            </div>
        );
    }


    render() {
        let productContents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Vending.renderProductsTable(this.state.products);

        let invoiceItemContents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Vending.renderInvoiceItemTable(this.state.invoiceItems);

        let invoiceContents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Vending.renderInvoiceTable(this.state.invoice);

        let paymentContents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Vending.renderPaymentTable(this.state.paymentData)

        return (
            <div>
                <div>
                    <h1 id="tableLabel" >Products</h1>
                    {productContents}
                </div>
                <div>
                    <h1 id="tableLabel" >Shopping Cart</h1>
                    {/*<button id='clearCartButton' className="btn btn-primary" onClick={clearCart()}>Clear Cart</button>*/}
                    {invoiceContents}
                </div>
                <div>
                    <h1 id="tableLabel" >Payment Details</h1>
                    {paymentContents}
                </div>
            </div>
        );
    }

    /// Product calls
    // Get All Products
    async getAllProducts() {
        const response = await fetch('Products');
        const data = await response.json();
        this.setState({products: data, loading: false})
    }

    // Get One Product
    async getProductById(id) {
        const response = await fetch('Products?Id=' + id);
        const data = await response.json();
        this.setState({ loading: false });
    }


    /// Invoice calls
    // Get All Invoices
    async getAllInvoices() {
        const response = await fetch('Invoices');
        const data = await response.json();
        this.setState({ invoices: data, loading: false})
    }

    // Get Once Invoice
    async getInvoiceById(id) {
        const response = await fetch('Invoices?Id=' + id);
        const data = await response.json();
        this.setState({invoice: data, loading: false })
    }

    // Update an Invoice
    // TODO: not complete yet.
    async updateInvoice() {

    }

    // Insert an Invoice
    async addInvoice(invoice) {
        const response = await fetch('Invoices', {
            method: "POST",
            header: { 'Content-Type': 'application/json' },
            body: JSON.stringify(invoice)
        }).then(res => {
            console.log("RequestComplete! response: ", res);
        });
    }


    /// Invoice Item calls
    // Get All Invoice Items
    async getInvoiceItems() {
        const response = await fetch('InvoiceItems');
        const data = await response.json();
        this.setState({ invoiceItems: data, loading: false })
    }

    // Get All Invoice Items for a specific Invoice.
    async getInvoiceItemData(invoiceId) {
        const response = await fetch('InvoiceItems/GetInvoiceItemsByInvoice?invoiceId=' + invoiceId);
        const data = await response.json();
        this.setState({invoiceItems: data, loading: false})
    }

    // Get Once Invoice Item
    // TODO: not complete yet.
    async getInvoiceItem(id) {

    }

    // Update an Invoice Item
    // TODO: not complete yet.
    async updateInvoice(invoiceItem) {

    }

    // Insert an Invoice Item.
    // TODO: not complete yet.
    async addInvoiceItem(invoiceItem) {

    }

    // Delete an Invoice Item.
    // TODO: not complete yet.
    async deleteInvoiceItem(id) {

    }


    /// Payment calls
    // Get All Payments
    // TODO: not complete yet.
    async getAllPayments() {

    }

    // Get One Payment.
    // TODO: not complete yet
    async getPayment(id) {

    }

    // Get One Payment for Invoice
    // TODO: not complete yet
    async getPaymentForInvoice(invoiceId) {

    }

    // Insert Payment
    // TODO: not complete yet.
    async addPayment(payment) {

    }

    // Update one Payment
    // TODO: not complete yet
    async updatePayment(payment) {

    }

    // Delete Payment
    // TODO: not complete yet.
    async deletePayment(id) {

    }

}

function clearCart() {
    Vending.invoiceItems = new [];
    Vending.invoice = new [];
    Vending.getAllProducts();
}

function getAddButtonOnClick(product) {
    switch (product.name) {
        case 'Soda':
            return Vending.sodaIncrementCounter
            break;
        case 'Candy Bar':
            return Vending.candyIncrementCounter
            break;
        case 'Chips':
            return Vending.chipsIncrementCounter
            break;

    }
}

function getRemoveButtonOnClick(name) {
    switch (name) {
        case 'Soda':
            return Vending.sodaDecrementCounter
            break;
        case 'Candy Bar':
            return Vending.candyDecrementCounter
            break;
        case 'Chips':
            return Vending.chipsDecrementCounter
            break;

    }
}
