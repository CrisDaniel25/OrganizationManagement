import { ThemePalette } from "@angular/material/core";

export interface NavItem {
    displayName: string;
    disabled?: boolean;
    iconName: string;
    route?: string;
    children?: NavItem[];
    visible?: boolean;
    isOpen: boolean;
    hasBadge: boolean;
    badgeColor: ThemePalette;
    badgeContent: number | string | null | undefined;
}
