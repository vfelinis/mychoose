import * as React from 'react';
import { Link } from 'react-router';
import * as AdminGiftStore from '../../store/AdminGift';

interface AdminGiftItemProps {
    data: AdminGiftStore.AdminGift;
}

export default class AdminGiftItem extends React.Component<AdminGiftItemProps, void> {
    public render() {
        return  <tr>
                <td>{this.props.data.name}</td>
                <td>{this.props.data.categories.join(', ')}</td>
                <td>{this.props.data.priceFrom}</td>
                <td>{this.props.data.priceTo}</td>
                <td><Link to={ `/admingift/update/${this.props.data.id}` } className="btn btn-primary btn-xs">Update</Link></td>
            </tr>;
    }
}
