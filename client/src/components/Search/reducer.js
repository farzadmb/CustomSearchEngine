import * as actionTypes from './actionTypes';

const initialState = {
    status: [],
    isLoading: true,
    error: null
};

const getLinkStatusRequest = (state) => ({ ...state, isLoading: true });

const getLinkStatusSuccess = (state, status) => ({ ...state, status, isLoading: false, error: null });

const getLinkStatusFailed = (state, error) => ({ ...state, isLoading: false, error });

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.GET_LINK_STATUS_REQUEST:
            return getLinkStatusRequest(state);
        case actionTypes.GET_LINK_STATUS_SUCCESS:
            return getLinkStatusSuccess(state, action.status);
        case actionTypes.GET_LINK_STATUS_FAILED:
            return getLinkStatusFailed(state, action.error);
        default:
            return state;
    }
};

export default reducer;