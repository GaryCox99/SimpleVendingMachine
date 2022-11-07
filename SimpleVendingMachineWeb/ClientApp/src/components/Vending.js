import React, { Component } from 'react';

export class Vending extends Component {
    static displayName = Vending.name;

    constructor(props) {
        super(props);
        this.state = {
            products: [],
            invoice: [],
            invoiceItems: [],
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
        this.populateProductData();

        //this.sodaIncrementCounter = this.sodaIncrementCounter.bind(this);
        //this.candyIncrementCounter = this.candyIncrementCounter.bind(this);
        //this.chipsIncrementCounter = this.chipsIncrementCounter.bind(this);

        //this.sodaDecrementCounter = this.sodaDecrementCounter.bind(this);
        //this.candyDecrementCounter = this.candyDecrementCounter.bind(this);
        //this.chipsDecrementCounter = this.chipsDecrementCounter.bind(this);
    }

    componentDidMount() {
        this.populateProductData();
    }

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

    //sodaDecrementCounter() {
    //    this.setState({
    //        sodaCounter: this.state.sodaCounter + 1
    //    });
    //}
    //candyDecrementCounter() {
    //    this.setState({
    //        candyCounter: this.state.candyCounter + 1
    //    });
    //}
    //chipsDecrementCounter() {
    //    this.setState({
    //        chipsCounter: this.state.chipsCounter + 1
    //    });
    //}

    //totalProductsCalculator() {
    //    this.setState({
    //        totalProducts: this.state.sodaInvoiceCounter + this.state.candyInvoiceCounter + this.state.chipsInvoiceCoutner
    //    })
    //}

    //totalDueCalculator() {
    //    this.setState({
    //        todalDue: this.sodaCalculatedTotal + this.candyCalculatedTotal + this.chipsCalculatedTotal
    //    })
    //}

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
                            <td><button className="btn btn-primary" onClick={getAddButtonOnClick(product.name)}>Add</button></td>
                            <td>{product.name}</td>
                            <td>{product.cost}</td>
                            <td>{product.quantity}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    //static renderInvoiceTable(invoice) {
    //    return (
    //        <table id='invoiceTable' className='table table-stripped' aria-labelledby="tableLabel">
    //            <tbody>
    //                <tr>
    //                   {/*<td>{invoiceItemContents}</td>*/}
    //                </tr>
    //            </tbody>
    //        </table>
    //    );
    //}

    //static renderInvoiceItemTable(invoiceItems) {
    //    return (
    //        <table id='invoiceItemTable' className='table table-stripped' aria-labelledby="tableLabel">
    //            <thead>
    //                <tr>
    //                    <th></th>
    //                    <th>Products</th>
    //                    <th>Qty</th>
    //                    <th>Total</th>
    //                </tr>
    //            </thead>
    //            <tbody>
    //                <tr>
    //                    {invoiceItems.map(invoiceItem => {
    //                            switch (invoiceItem.Name) {
    //                                case "Soda":
    //                                    <tr key={invoiceItem.Name}>
    //                                        <td><button className="btn btn-primary" onClick={this.sodaDecrementCounter}>Remove</button></td>
    //                                        <td>{invoiceItem.Name}</td>
    //                                        <td>x {this.sodaInvoiceCounter}</td>
    //                                        <td>$ {this.sodaCalculatedTotal}</td>
    //                                    </tr>
    //                                    break;
    //                                case "Candy Bar":
    //                                    <tr key={invoiceItem.Name}>
    //                                        <td><button className="btn btn-primary" onClick={this.candyDecrementCounter}>Remove</button></td>
    //                                        <td>{invoiceItem.Name}</td>
    //                                        <td>x {this.candyInvoiceCounter}</td>
    //                                        <td>$ {this.candyCalculatedTotal}</td>
    //                                    </tr>
    //                                    break;
    //                                case "Chips":
    //                                    <tr key={invoiceItem.Name}>
    //                                        <td><button className="btn btn-primary" onClick={this.chipsDecrementCounter}>Remove</button></td>
    //                                        <td>{invoiceItem.Name}</td>
    //                                        <td>x {this.chipsInvoiceCounter}</td>
    //                                        <td>$ {this.chipsCalculatedTotal}</td>
    //                                    </tr>
    //                                    break;
    //                                default:
    //                                    <></>
    //                            }
    //                        }
    //                        )}
    //                </tr>
    //            </tbody>
    //        </table>
    //    );
    //}

    //static renderPaymentTable(paymentData) {
    //    return (
    //        <table id='paymentTable' className='table table-stripped' aria-labelledby="tableLabel">
    //            <tbody>
    //                <tr>
    //                    <td>Total Products: {this.TotalProducts}</td>
    //                    <td>Total Due: {this.totalDue}</td>
    //                </tr>
    //                <tr>
    //                    <td>Name On Card: {paymentData.NameOnCard}</td>                        
    //                </tr>
    //                <tr>
    //                    <td>Credit Card Number: {paymentData.CreditCardNumber}</td>
    //                </tr>
    //                <tr>
    //                    <td>Expiration: {paymentData.CreditCardExpiration}</td>
    //                    <td>CVV: {paymentData.CreditCardCVV}</td>
    //                </tr>
    //                <tr>
    //                    <td>Status: {paymentData.TransactionStatus}</td>
    //                </tr>
    //            </tbody>
    //        </table>
    //    )
    //}


    render() {
        let productContents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Vending.renderProductsTable(this.state.products);
        //let invoiceItemContents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : Vending.renderInvoiceItemTable(this.state.invoice);
        //let invoiceContents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : Vending.renderInvoiceTable(this.state.invoice.map(Id => {invoiceItemContents(Id) }));
        //let paymentContents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : Vending.renderPaymentTable(this.state.paymentData)

        return (
            <div>
                <h1 id="tableLabel" >Products</h1>
                {productContents }
            </div>
        );
    }

    

    async populateProductData() {
        const response = await fetch('Products');
        const data = await response.json();
        this.setState({products: data, loading: false})

    }
}

function getAddButtonOnClick(name) {
    switch (name) {
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
