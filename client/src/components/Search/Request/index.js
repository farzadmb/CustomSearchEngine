import React, { useState } from 'react';
import { useDispatch } from 'react-redux';

import EngineSelector from '../EngineSelector';
import { Border, Input, Button } from './styled';
import * as actions from '../actions';

const Request = (props) => {
    const dispatch = useDispatch();

    const engines = ['Google'];

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

    const canSearch = () => {
        return query.trim().length > 0 && link.trim().length > 0;
    };

    return (
        <Border>
            <Input placeholder='Search Query' text={query} onChange={(event) => { queryChangeHandler(event.target.value); }} />
            <Input placeholder='Link to check' text={link} onChange={(event) => { linkChangeHandler(event.target.value); }} />
            <EngineSelector options={engines} value={engine} onChange={(event) => { engineChangeHandler(event.target.value); }} />
            <Button onClick={onGetStatus} disabled={!canSearch()}>Search</Button>
        </Border>
    );
}

export default Request;