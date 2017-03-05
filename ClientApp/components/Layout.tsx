import * as React from 'react';
import { NavMenu } from './NavMenu';

export interface LayoutProps {
    body: React.ReactElement<any>;
}

export class Layout extends React.Component<LayoutProps, void> {
    public render() {
        return <div className='container-fluid'>
            <NavMenu />
            <div className="container body-content">
                { this.props.body }
            </div>
        </div>;
    }
}
