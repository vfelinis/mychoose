import * as React from 'react';
import { Link } from 'react-router';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as GiftStore from '../store/Gift';

type GiftProps = GiftStore.GiftState & typeof GiftStore.actionCreators;

class Gift extends React.Component<GiftProps, void> {
    public render() {
        return <div>

            <div className="gift">{ this.props.gift }</div>

            <button onClick={ () => { this.props.requestGift() } } className="btn btn-default btn-lg">Play</button>
        </div>;
    }
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.gift, // Selects which state properties are merged into the component's props
    GiftStore.actionCreators                 // Selects which action creators are merged into the component's props
)(Gift);
