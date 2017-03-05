import * as React from 'react';
import Gift from './Gift';

export default class Home extends React.Component<void, void> {
    public render() {
        return <div>
            <h1>Сыграй и получи идею для подарка</h1>
            <Gift />
        </div>;
    }
}
