import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState }  from '../../store';
import * as AdminGiftStore from '../../store/AdminGift';

type UpdateGiftProps =
    AdminGiftStore.AdminGiftState     // ... state we've requested from the Redux store
    & typeof AdminGiftStore.actionCreators   // ... plus action creators we've requested
    & { params: { id: number } };       // ... plus incoming routing parameters

type UpdateGiftSate = AdminGiftStore.AdminGift;


class UpdateGift extends React.Component<UpdateGiftProps, UpdateGiftSate> {
    constructor(props) {
        super(props);
        this.state = {
            id: 0,
            name: '',
            createDate: null,
            updateDate: null,
            priceFrom: 0,
            priceTo: 0,
            categories: []
        };
    }
    componentDidMount() {
        if (this.props.gifts.length > 0) {
            let id = this.props.params.id;
            let gift = null;
            for (let i = 0; i < this.props.gifts.length; i++) {
                if (this.props.gifts[i].id == id) {
                    gift = this.props.gifts[i];
                    break;
                }
            }
            this.setState({
                ...gift
            });
        }
        else {
            this.props.redirect('/admingift');
        }
    }
    public render() {
        return <div>
            <h1>Update gift</h1>
            <div className="col-sm-6">
            <form className="form">
                <div className="form-group">
                    <label>Name:</label>
                    <input value={this.state.name} type="text" className="form-control" />
                </div>
                <div className="form-group">
                    <label>PriceFrom:</label>
                    <select value={this.state.priceFrom} className="form-control">
                        {
                            this.props.prices.map((price, key) => <option key={key} value={price}>{price}</option>)
                        }
                    </select>
                </div>
                <div className="form-group">
                    <label>PriceTo: </label>
                    <select value={this.state.priceTo} className="form-control">
                        {
                            this.props.prices.map((price, key) => <option key={key} value={price}>{price}</option>)
                        }
                    </select>
                </div>
                <button type="submit" className="btn btn-default">Submit</button>
            </form>
            </div>
            <div className="col-sm-6">
                <ul>
                    {
                        this.state.categories.map((category, key) => <li key={key}>{category}</li>)
                    }
                </ul>
            </div>
        </div>;
    }
}
export default connect(
    (state: ApplicationState) => state.admingift, // Selects which state properties are merged into the component's props
    AdminGiftStore.actionCreators                 // Selects which action creators are merged into the component's props
)(UpdateGift);
