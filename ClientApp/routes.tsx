import * as React from 'react';
import { Router, Route, HistoryBase } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import AdminGift from './components/admin/AdminGift';
import UpdateGift from './components/admin/UpdateGift';

export default <Route component={ Layout }>
    <Route path='/' components={{ body: Home }} />
    <Route path='/admingift' components={{ body: AdminGift }} />
    <Route path='/admingift/update/:id' components={{ body: UpdateGift }} />
    {/*<Route path='/counter' components={{ body: Counter }} />
    <Route path='/fetchdata' components={{ body: FetchData }}>
        <Route path='(:startDateIndex)' />
    </Route>*/}
</Route>;

// Enable Hot Module Replacement (HMR)
if (module.hot) {
    module.hot.accept();
}
