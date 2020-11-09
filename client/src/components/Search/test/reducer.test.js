import * as actionTypes from '../actionTypes';
import reducer from '../reducer';

describe('Search reducer', () => {
    test('should handle GET_LINK_STATUS_REQUEST', () => {
        const action = { type: actionTypes.GET_LINK_STATUS_REQUEST };
        expect(reducer({}, action)).toEqual({
            searchResult: null,
            isLoading: false,
            error: null
        });
    })
});