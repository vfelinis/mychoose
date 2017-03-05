import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';
import { push } from 'react-router-redux';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface AdminGiftState {
    isLoading: boolean;
    gifts: AdminGift[];
    prices: number[];
    categories: string[];
}

export interface AdminGift {
    id: number;
    name: string;
    createDate: Date;
    updateDate: Date;
    priceFrom: number;
    priceTo: number;
    categories: string[];
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestAdminGiftAction {
    type: 'REQUEST_ADMIN_GIFTS'
}

interface ReceiveAdminGiftAction {
    type: 'RECEIVE_ADMIN_GIFTS',
    data: FetchData;
}

interface FetchData {
    gifts: AdminGift[];
    prices: number[];
    categories: string[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestAdminGiftAction | ReceiveAdminGiftAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestAdminGift: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        let fetchTask = fetch('/api/admingift')
            .then(response => response.json() as Promise<AdminGift[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_ADMIN_GIFTS', data: data });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_ADMIN_GIFTS' });
    },
    redirect: (path) => (dispatch, getState) => {
        dispatch(push(path));
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: AdminGiftState = { isLoading: false, gifts: [], prices: [], categories: [] };

export const reducer: Reducer<AdminGiftState> = (state: AdminGiftState, action: KnownAction) => {
    switch (action.type) {
        case 'REQUEST_ADMIN_GIFTS':
            return {
                isLoading: true,
                gifts: state.gifts,
                prices: state.prices,
                categories: state.categories
            };
        case 'RECEIVE_ADMIN_GIFTS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                isLoading: false,
                gifts: action.data.gifts,
                prices: action.data.prices,
                categories: action.data.categories
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
