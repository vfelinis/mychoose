import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface GiftState {
    isLoading: boolean;
    gift: string;
}


// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestGiftAction {
    type: 'REQUEST_GIFT'
}

interface ReceiveGiftAction {
    type: 'RECEIVE_GIFT',
    data: string;
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestGiftAction | ReceiveGiftAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestGift: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        let fetchTask = fetch(`/api/data`)
            .then(response => response.json() as Promise<any>)
            .then(data => {
                dispatch({ type: 'RECEIVE_GIFT', data: data.gift });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_GIFT' });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: GiftState = { isLoading: false, gift: '' };

export const reducer: Reducer<GiftState> = (state: GiftState, action: KnownAction) => {
    switch (action.type) {
        case 'REQUEST_GIFT':
            return {
                isLoading: true,
                gift: state.gift
            };
        case 'RECEIVE_GIFT':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                isLoading: false,
                gift: action.data
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
