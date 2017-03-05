import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState }  from '../../store';
import * as AdminGiftStore from '../../store/AdminGift';
import AdminGiftItem from './AdminGiftItem';

type AdminGiftProps = AdminGiftStore.AdminGiftState & typeof AdminGiftStore.actionCreators;

class AdminGift extends React.Component<AdminGiftProps, void> {
    componentDidMount() {
        this.props.requestAdminGift();
    }
    public render() {
        return <div>
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Gift</th>
                        <th>Category</th>
                        <th>PriceFrom</th>
                        <th>PriceTo</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.gifts.map((item, key) => {
                            return <AdminGiftItem key={key} data={item} />;
                        })
                    }
                </tbody>
            </table>
        </div>;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.admingift, // Selects which state properties are merged into the component's props
    AdminGiftStore.actionCreators                 // Selects which action creators are merged into the component's props
)(AdminGift);
