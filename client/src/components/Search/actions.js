import axios from 'axios';

import * as actionTypes from './actionTypes';

const baseUrl = 'http://localhost:8090';

const getLinkStatus = (searchEngine, query, link) => (
    (dispatch) => {
        axios.post(baseUrl, { searchEngine, query, link }).then(response => {
            dispatch({ type: actionTypes.GET_LINK_STATUS_SUCCESS, status: response.data });
        }).catch(error => {
            dispatch({ type: actionTypes.GET_LINK_STATUS_SUCCESS, error });
        });
    }
);

export {
    getLinkStatus
};