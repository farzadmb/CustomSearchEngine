import axios from 'axios';

import * as actionTypes from './actionTypes';

const baseUrl = 'http://www.localhost:8090/api';

const getLinkStatus = ({ engine, query, link }) => (
    (dispatch) => {
        dispatch({ type: actionTypes.GET_LINK_STATUS_REQUEST });

        axios.post(`${baseUrl}/search/checkLinkStatus`, { searchEngine: engine, query, link }).then(response => {
            dispatch({ type: actionTypes.GET_LINK_STATUS_SUCCESS, status: response.data });
        }).catch(error => {
            dispatch({ type: actionTypes.GET_LINK_STATUS_FAILED, error });
        });
    }
);

export {
    getLinkStatus
};