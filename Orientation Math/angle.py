import numpy as np
import matplotlib.pyplot as plt

def Rzy(vec : np.ndarray, phi, theta):
    R = np.array([[np.cos(phi) * np.cos(theta), np.sin(phi), np.cos(phi) * np.sin(theta)],
                  [np.cos(phi) * np.cos(theta), np.sin(phi), np.cos(phi) * np.sin(theta)]
                  [np.cos(phi) * np.cos(theta), np.sin(phi), np.cos(phi) * np.sin(theta)]])
    return vec @ R