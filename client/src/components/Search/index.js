import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import Request from './Request';
import Result from './Result';
import * as actions from './actions';
import { Box, Separator } from './styled';

const Search = (props) => {
    const dispatch = useDispatch();

    const engines = ['Google'];
    const status = useSelector(state => state.search.status);
    const error = useSelector(state => state.search.error);

    const [query, setQuery] = useState('');
    const [link, setLink] = useState('');
    const [engine, setEngine] = useState('Google');

    const queryChangeHandler = (value) => {
        setQuery(value);
    };

    const linkChangeHandler = (value) => {
        setLink(value);
    };

    const engineChangeHandler = (value) => {
        setEngine(value);
    };

    const onGetStatus = () => {
        dispatch(actions.getLinkStatus({ engine, query, link }));
    };

    return (
        <Box>
            <Request
                engines={engines}
                query={query}
                link={link}
                engine={engine}
                onGetStatus={onGetStatus}
                queryChangeHandler={queryChangeHandler}
                linkChangeHandler={linkChangeHandler}
                engineChangeHandler={engineChangeHandler} />
            <Separator />
            <Result status={status} error={error} />
        </Box>
    );
};

export default Search;