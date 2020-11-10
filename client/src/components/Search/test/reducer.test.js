import * as actionTypes from '../actionTypes';
import reducer from '../reducer';

describe('Search reducer', () => {
    test('should handle GET_LINK_STATUS_REQUEST', () => {
        const action = { type: actionTypes.GET_LINK_STATUS_REQUEST };
        expect(reducer({}, action)).toEqual({
            isLoading: true,
            error: null
        });
    });

    test('should handle GET_LINK_STATUS_SUCCESS', () => {
        const result = { resultItems: [] };
        const action = { type: actionTypes.GET_LINK_STATUS_SUCCESS, searchResult: result };
        expect(reducer({}, action)).toEqual({
            searchResult: result,
            isLoading: false,
            error: null
        });
    });

    test('should handle GET_LINK_STATUS_FAILED', () => {
        const error = 'error';
        const action = { type: actionTypes.GET_LINK_STATUS_FAILED, error };
        expect(reducer({}, action)).toEqual({
            searchResult: null,
            isLoading: false,
            error
        });
    });
});