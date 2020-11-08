import React from 'react';

import { Select } from './styled';

const EngineSelector = (props) => {
    const { options, value, disabled, onChange } = props;

    let listOptions = [];
    let isDisabled = true;

    if (options) {
        listOptions = options.map(o => <option key={o} value={o}>{o}</option>);
        isDisabled = disabled;
    }

    const isDropdownDisabled = isDisabled ? { disabled: 'disabled' } : {};

    return (
        <Select {...isDropdownDisabled} value={value} onChange={onChange}>{listOptions}</Select>
    );
}

export default EngineSelector;