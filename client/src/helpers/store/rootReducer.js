import { combineReducers } from '../../../node_modules/redux';

import searchReducer from '../../components/Search/reducer';

const rootReducer = combineReducers({
    search: searchReducer
});

export default rootReducer;