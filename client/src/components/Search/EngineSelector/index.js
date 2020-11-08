import React from 'react';

import { Select } from './styled';

const EngineSelector = (props) => {
    const { options, disabled } = props;

    let listOptions = [];
    let isDisabled = true;

    if (options) {
        listOptions = options.map(o => <option key={o} value={o}>{o}</option>);
        isDisabled = disabled;
    }

    const isDropdownDisabled = isDisabled ? { disabled: 'disabled' } : {};


    return (
        <Select {...isDropdownDisabled}>{listOptions}</Select>
    );
}

export default EngineSelector;